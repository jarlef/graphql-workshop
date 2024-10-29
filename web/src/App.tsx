import { Header } from '@/layout';
import { AlbumPage } from '@/pages/album';
import { ArtistPage } from '@/pages/artist';
import { CategoryPage } from '@/pages/category';
import { HomePage } from '@/pages/home';
import React from 'react';
import { Route, BrowserRouter as Router, Routes } from 'react-router-dom';
import './App.scss';

export const App: React.FC = () => {
  return (
    <div style={{ minWidth: 1080 }}>
      <Router>
        <Header />
        <main>
          <Routes>
            <Route path="/artist/:id" element={<ArtistPage />} />
            <Route path="/album/:id" element={<AlbumPage />} />
            <Route path="/category/:id" element={<CategoryPage />} />
            <Route path="/" element={<HomePage />} />
          </Routes>
        </main>
      </Router>
    </div>
  );
};
