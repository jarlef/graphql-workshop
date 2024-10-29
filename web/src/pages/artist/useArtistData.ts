export type Artist = {
  id: number;
  name: string;
};

export const useArtistData = () => {
  return {
    id: 1,
    name: 'AC/DC',
  } as Artist;
};
