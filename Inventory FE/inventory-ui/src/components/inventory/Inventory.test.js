import { render, screen } from '@testing-library/react';
import Inventory from './Inventory';

test('renders learn react link', () => {
    render(<Inventory></Inventory>);
  const linkElement = screen.getByText(/learn react/i);
  expect(linkElement).toBeInTheDocument();
});
