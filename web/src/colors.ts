import randomColor from 'randomcolor';

const data = randomColor({ count: 1000, seed: 'miles', luminosity: 'dark' });

export const colors = data;
