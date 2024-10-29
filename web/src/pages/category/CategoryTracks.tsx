import { CategoryDetailsFragment } from '@/pages/category/operations/category-details.gql';
import { Paper, Table, TableBody, TableCell, TableContainer, TableHead, TableRow } from '@mui/material';
import React from 'react';

type CategoryTracksProps = {
  category: CategoryDetailsFragment;
};

export const CategoryTracks: React.FC<CategoryTracksProps> = ({ category }) => {
  console.log(category.id);
  return (
    <TableContainer component={Paper} className="table">
      <Table sx={{ minWidth: 650 }} aria-label="simple table">
        <TableHead>
          <TableRow>
            <TableCell>Track</TableCell>
            <TableCell>Album</TableCell>
            <TableCell>Artist</TableCell>
            <TableCell>Duration</TableCell>
            <TableCell align="right">Price</TableCell>
          </TableRow>
        </TableHead>
        <TableBody>
          {/*category.tracks?.map(track => (
            <TableRow key={track.id}>
              <TableCell component="th" scope="row">
                {track.name}
              </TableCell>
              <TableCell>
                <Link to={`/album/${track.album.id}`}>{track.album.title}</Link>
              </TableCell>
              <TableCell>
                <Link to={`/artist/${track.album.artist.id}`}>{track.album.artist.name}</Link>
              </TableCell>
              <TableCell>{track.duration}</TableCell>
              <TableCell align="right">-</TableCell>
            </TableRow>
          ))*/}
        </TableBody>
      </Table>
    </TableContainer>
  );
};
