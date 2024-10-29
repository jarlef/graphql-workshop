import { useArtistData } from '@/pages/artist/useArtistData';
import { useWikiInfo } from '@/pages/artist/useWikiInfo';
import { Card, CardContent, Typography } from '@mui/material';
import React from 'react';
import { useParams } from 'react-router-dom';

export const ArtistPage: React.FC = () => {
  const { id } = useParams<{ id: string }>();
  console.log(`Artist: ${id}`);

  // TODO: load artist from server
  const artist = useArtistData();
  const { page } = useWikiInfo(artist);

  return (
    <Card>
      <CardContent>
        <Typography variant="h2" gutterBottom>
          {artist.name}
        </Typography>
        <Typography variant="body1" gutterBottom>
          {page?.thumbnail && <img src={page.thumbnail.source} style={{ float: 'left', margin: 20 }} />}
          {page?.extract}
        </Typography>
      </CardContent>
    </Card>
  );
};
