import { Card, CardContent, Rating, Typography } from '@mui/material';
import React from 'react';
import { Link } from 'react-router-dom';
import { Album } from './useAlbumData';

type AlbumTileProps = {
  album: Album;
};

export const AlbumTile: React.FC<AlbumTileProps> = ({ album }) => {
  return (
    <Card>
      <CardContent>
        <Typography variant="h4" gutterBottom>
          <Link to={`/artist/${album.artist.id}`}>{album.artist.name}</Link>
        </Typography>
        <Typography variant="h2" gutterBottom>
          {album.name}
        </Typography>
        <Rating value={0} />
      </CardContent>
    </Card>
  );
};
