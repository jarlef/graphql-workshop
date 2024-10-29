import { CircularProgress } from '@mui/material';

export const DataLoading = () => {
  return (
    <div className="center">
      <CircularProgress variant="indeterminate" />
    </div>
  );
};
