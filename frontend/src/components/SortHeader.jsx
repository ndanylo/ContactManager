import React from "react";

const SortHeader = ({ label, onSort }) => {
  return <th onClick={onSort}>{label}</th>;
};

export default SortHeader;
