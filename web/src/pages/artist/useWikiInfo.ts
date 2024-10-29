import { Artist } from '@/pages/artist/useArtistData';
import { useAsync } from 'react-use';
interface Thumbnail {
  source: string;
}

interface Page {
  title: string;
  extract: string;
  thumbnail?: Thumbnail;
}
export const useWikiInfo = (artist: Artist) => {
  const result = useAsync(async () => {
    if (!artist?.id) {
      return null;
    }

    const pageResult = await fetch(
      `https://en.wikipedia.org/w/api.php?origin=*&format=json&action=query&prop=extracts&exintro&explaintext&redirects=1&titles=${artist.name}`,
    ).then(res => res.json());

    if (!pageResult?.query?.pages) {
      return null;
    }

    const pageId = Object.keys(pageResult.query.pages)[0];
    if (!pageId || pageId === '-1') {
      return null;
    }

    let page = pageResult.query.pages[pageId];

    const summary = await fetch(
      `https://en.wikipedia.org/api/rest_v1/page/summary/${encodeURIComponent(page.title)}`,
    ).then(res => res.json());

    if (summary?.thumbnail) {
      page = { ...page, thumbnail: summary.thumbnail };
    }

    return page as Page;
  }, [artist.id]);

  return { page: result.value, loading: result.loading };
};
