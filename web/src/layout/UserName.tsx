import { User } from '@/generated/graphql';
import { useUserUpdatesSubscription } from '@/layout/operations/subscribe-me.gql';

type UserNameProps = {
  user: User;
};

export const UserName: React.FC<UserNameProps> = ({ user }) => {
  useUserUpdatesSubscription({
    variables: {
      userId: user.id,
    },
  });
  return <>{user.name}</>;
};
