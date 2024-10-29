import { Alert } from '@mui/material';

export const DataError = () => {
  return (
    <div className="center">
      <Alert severity="error">Unable to load data</Alert>
    </div>
  );
};
