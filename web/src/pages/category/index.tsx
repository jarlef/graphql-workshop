import { CategoryTile } from '@/pages/category/CategoryTile';
import { CategoryTracks } from '@/pages/category/CategoryTracks';
import { CategoryDetailsFragment } from '@/pages/category/operations/category-details.gql';
import { useGetCategoryQuery } from '@/pages/category/operations/get-category.gql';
import { CircularProgress, Grid } from '@mui/material';
import React from 'react';
import { useParams } from 'react-router-dom';

export const CategoryPage: React.FC = () => {
  const { id } = useParams<{ id: string }>();
  console.log(`Category: ${id}`);
  const { data } = useGetCategoryQuery({
    variables: {
      categoryId: Number(id),
    },
  });

  const category = data?.category as CategoryDetailsFragment;

  if (!category) {
    return <CircularProgress variant="indeterminate" />;
  }

  return (
    <Grid container>
      <Grid item xs={3} padding={2}>
        <CategoryTile category={category} />
      </Grid>
      <Grid item xs={9} padding={2}>
        <CategoryTracks category={category} />
      </Grid>
    </Grid>
  );
};
