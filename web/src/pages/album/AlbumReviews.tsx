import { Album } from '@/pages/album/useAlbumData';
import { ThumbDown, ThumbUp } from '@mui/icons-material';
import { Box, Grid, IconButton, List, ListItem, ListItemText, Rating, Typography } from '@mui/material';
import React from 'react';

type AlbumReviewsProps = {
  album: Album;
};

export const AlbumReviews: React.FC<AlbumReviewsProps> = ({ album }) => {
  return (
    <Box sx={{ mt: 'auto' }}>
      <List>
        {album.reviews?.map(x => (
          <ListItem divider key={x.id}>
            <ListItemText
              primary={
                <Box>
                  <Box>
                    <Rating value={x.rating} disabled size="small" />
                  </Box>
                  <Box padding={1}>{x.comment}</Box>
                </Box>
              }
              secondary={
                <>
                  <Typography variant="body2" component="span" color="text.primary">
                    {x.author}
                  </Typography>
                  {` - ${x.timestamp}`}
                  <Grid container spacing={1} sx={{ mt: 0.5 }} alignItems="center">
                    <Grid item>
                      <IconButton aria-label="Upvote" size="small">
                        <ThumbUp fontSize="inherit" />
                      </IconButton>
                    </Grid>
                    <Grid item>
                      <Typography variant="body1" color="text.primary" fontWeight="500">
                        {x.upVotes}
                      </Typography>
                    </Grid>
                    <Grid item sx={{ ml: 0.5 }}>
                      <IconButton aria-label="Downvote" size="small">
                        <ThumbDown fontSize="inherit" />
                      </IconButton>
                    </Grid>
                    <Grid item>
                      <Typography variant="body1" color="text.primary" fontWeight="500">
                        {x.downVotes}
                      </Typography>
                    </Grid>
                  </Grid>
                </>
              }
            />
          </ListItem>
        ))}
      </List>
    </Box>
  );
};
