import { AddReview } from '@/pages/album/AddReview';
import { AlbumReviews } from '@/pages/album/AlbumReviews';
import { AlbumTile } from '@/pages/album/AlbumTile';
import { AlbumTracks } from '@/pages/album/AlbumTracks';
import { Grid, Typography } from '@mui/material';
import React from 'react';
import { useParams } from 'react-router-dom';
import { useAlbumData } from './useAlbumData';

export const AlbumPage: React.FC = () => {
  const { id } = useParams<{ id: string }>();
  console.log(`Album: ${id}`);
  // TODO: load album from server
  const album = useAlbumData();

  return (
    <Grid container>
      <Grid item xs={6} padding={2}>
        <AlbumTile album={album} />
        <AlbumTracks album={album} />
      </Grid>
      <Grid item xs={6} padding={2}>
        <Typography variant="h5">Reviews</Typography>
        <AddReview />
        <AlbumReviews album={album} />
      </Grid>
    </Grid>
  );
};
