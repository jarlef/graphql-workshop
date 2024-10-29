import { Album } from '@/pages/album/useAlbumData';
import { formatDuration } from '@/time';
import { Chip, Paper, Table, TableBody, TableCell, TableContainer, TableHead, TableRow } from '@mui/material';
import React from 'react';
import { Link } from 'react-router-dom';

type AlbumTracksProps = {
  album: Album;
};

export const AlbumTracks: React.FC<AlbumTracksProps> = ({ album }) => {
  return (
    <TableContainer component={Paper} className="table">
      <Table sx={{ minWidth: 650 }} aria-label="simple table">
        <TableHead>
          <TableRow>
            <TableCell>Track</TableCell>
            <TableCell>Categories</TableCell>
            <TableCell>Duration</TableCell>
            <TableCell align="right">Price</TableCell>
          </TableRow>
        </TableHead>
        <TableBody>
          {album.tracks.map(track => (
            <TableRow key={track.id}>
              <TableCell component="th" scope="row">
                {track.name}
              </TableCell>
              <TableCell component="th" scope="row">
                <Chip
                  component={Link}
                  to={`/category/${track.category.id}`}
                  className="quick-link"
                  label={track.category.name}
                  color="primary"
                  variant="outlined"
                  clickable
                />
              </TableCell>
              <TableCell>{formatDuration(track.duration)}</TableCell>
              <TableCell align="right">{track.price}</TableCell>
            </TableRow>
          ))}
        </TableBody>
      </Table>
    </TableContainer>
  );
};
