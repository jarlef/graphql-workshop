import { colors } from '@/colors';
import { CategoryDetailsFragment } from '@/pages/category/operations/category-details.gql';
import { Card, CardContent, Typography } from '@mui/material';
import React from 'react';

type CategoryTileProps = {
  category: CategoryDetailsFragment;
};

export const CategoryTile: React.FC<CategoryTileProps> = ({ category }) => {
  return (
    <Card>
      <CardContent style={{ backgroundColor: colors[category.id] }}>
        <Typography variant="h2" gutterBottom>
          {category.name}
        </Typography>
      </CardContent>
    </Card>
  );
};
