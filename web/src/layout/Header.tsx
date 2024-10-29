import { useGetMeQuery } from '@/layout/operations/get-me.gql';
import { UserName } from '@/layout/UserName';
import { AppBar, Box, Toolbar, Typography } from '@mui/material';
import React from 'react';
import { Link, useLocation } from 'react-router-dom';

export const Header: React.FC = () => {
  const location = useLocation();
  const { data } = useGetMeQuery();

  if (location.pathname === '/') {
    return null;
  }

  return (
    <AppBar position="static">
      <Toolbar>
        <Typography className="home" variant="h6" component="div" sx={{ flexGrow: 1 }}>
          <Link to="/"> Jukebox</Link>
        </Typography>
        <Box sx={{ flexGrow: 1 }}></Box>
        <Box sx={{ flexGrow: 0 }}>{data?.me && <UserName user={data!.me} />}</Box>
      </Toolbar>
    </AppBar>
  );
};
