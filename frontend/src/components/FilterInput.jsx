import React from "react";

const FilterInput = ({ filterText, onFilterChange }) => {
  return (
    <input
      type="text"
      placeholder="Filter contacts"
      value={filterText}
      onChange={(e) => onFilterChange(e.target.value)}
    />
  );
};

export default FilterInput;
