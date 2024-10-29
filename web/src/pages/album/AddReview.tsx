import { Button, Grid, Rating, TextField } from '@mui/material';
import { Box } from '@mui/system';
import { useState } from 'react';

export const AddReview = () => {
  const [comment, setComment] = useState<string>('');
  const [rating, setRating] = useState<number>(0);

  const submitReview = () => {
    // TODO: submit review to server
    setComment('');
    setRating(0);
  };
  return (
    <Box sx={{ mt: 'auto' }}>
      <Grid container spacing={2} sx={{ p: 2 }}>
        <Grid item xs>
          <Box padding={2}>
            <Rating value={rating} onChange={(_, value) => setRating(value ?? 0)} />
          </Box>
          <TextField
            multiline
            label="Comment"
            rows={2}
            sx={{ width: '100%' }}
            value={comment}
            onChange={e => setComment(e.target.value)}
          />
        </Grid>
        <Grid item alignSelf="flex-end">
          <Button onClick={() => submitReview()}>Add</Button>
        </Grid>
      </Grid>
    </Box>
  );
};
