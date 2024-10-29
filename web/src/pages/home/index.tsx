import { colors } from '@/colors';
import { DataError } from '@/components/DataError';
import { DataLoading } from '@/components/DataLoading';
import { useGetCategoriesQuery } from '@/pages/home/operations/get-categories.gql';
import MusicNoteIcon from '@mui/icons-material/MusicNote';
import { Paper, styled, Typography } from '@mui/material';
import { motion } from 'framer-motion';
import React from 'react';
import { Link } from 'react-router-dom';
import styles from './index.module.scss';

export const HomePage: React.FC = () => {
  const { data, loading, error } = useGetCategoriesQuery();

  return (
    <Content>
      <Typography className="title" gutterBottom variant="h1" component="div">
        <MusicNoteIcon className="logo" />
        <span>ukebox</span>
      </Typography>
      {loading && <DataLoading />}
      {error && <DataError />}
      <div className={styles.categoryList}>
        {!loading &&
          data?.categories?.map(c => (
            <motion.div
              key={c.id}
              initial={{ scale: 0, rotate: 180 }}
              animate={{ rotate: 0, scale: 1 }}
              transition={{
                type: 'spring',
                stiffness: 260,
                damping: 35,
              }}
            >
              <Link to={`/category/${c.id}`}>
                <Paper
                  elevation={6}
                  className={styles.category}
                  variant="elevation"
                  style={{ backgroundColor: colors[c.id] }}
                  square={false}
                >
                  <Typography
                    gutterBottom
                    variant="h4"
                    component="div"
                    margin={0}
                    style={{ overflow: 'hidden', textOverflow: 'ellipsis' }}
                  >
                    {c.name}
                  </Typography>
                </Paper>
              </Link>
            </motion.div>
          ))}
      </div>
    </Content>
  );
};

const Content = styled('div')`
  width: 100%;
  min-height: 100vh;
  justify-content: center;
  align-items: center;
  & a {
    text-decoration: none;
    color: ${({ theme: { palette } }) => palette.primary.main};
  }
`;
