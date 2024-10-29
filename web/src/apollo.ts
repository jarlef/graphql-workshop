import { ApolloClient, DefaultOptions, from, HttpLink, InMemoryCache, split } from '@apollo/client';
import { onError } from '@apollo/client/link/error';
import { RetryLink } from '@apollo/client/link/retry';
import { TypedTypePolicies } from './generated/apollo-helpers';
import introspectionResult from './generated/introspection-result';

import { GraphQLWsLink } from '@apollo/client/link/subscriptions';
import { getMainDefinition } from '@apollo/client/utilities';
import { createClient } from 'graphql-ws';

const errorLink = onError(({ graphQLErrors, networkError }) => {
  if (graphQLErrors)
    graphQLErrors.forEach(({ message, locations, path }) =>
      console.log(`[GraphQL error]: Message: ${message}, Location: ${locations}, Path: ${path}`),
    );
  if (networkError) console.log(`[Network error]: ${networkError}`);
});

const createHttpLink = () => {
  const httpLink = new HttpLink({
    uri: '/graphql',
    credentials: 'same-origin',
  });

  return httpLink;
};

const createWsLink = () => {
  const graphqlWsClient = createClient({
    url: '/graphql',
  });
  const wsLink = new GraphQLWsLink(graphqlWsClient);
  return wsLink;
};

export const createNetworkLink = () => {
  const networkLink = split(
    ({ query }) => {
      const definition = getMainDefinition(query);
      return definition.kind === 'OperationDefinition' && definition.operation === 'subscription';
    },
    createWsLink(),
    createHttpLink(),
  );

  return networkLink;
};

const link = from([errorLink, new RetryLink(), createNetworkLink()]);

const typePolicies: TypedTypePolicies = {};

const cache = new InMemoryCache({
  possibleTypes: introspectionResult.possibleTypes,
  typePolicies,
});

const defaultOptions: DefaultOptions = {
  watchQuery: {
    fetchPolicy: 'cache-and-network',
    nextFetchPolicy: 'cache-first',
  },
  query: {
    fetchPolicy: 'cache-first',
  },
};

export default new ApolloClient({
  link,
  cache,
  defaultOptions,
});
