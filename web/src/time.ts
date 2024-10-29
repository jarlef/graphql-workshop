export const formatDuration = (durationInSeconds: number) => {
  const minutes = ~~(durationInSeconds / 60);
  const seconds = ~~(durationInSeconds % 60);
  return minutes + ':' + seconds;
};
