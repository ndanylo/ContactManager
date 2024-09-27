import React from "react";

const ContactRow = ({ contact, handleEdit, handleDelete }) => {
  return (
    <tr>
      <td>{contact.name}</td>
      <td>{new Date(contact.birthday).toLocaleDateString()}</td>
      <td>{contact.phone}</td>
      <td>{contact.salary}</td>
      <td>{contact.isMarried ? "Married" : "Single"}</td>
      <td>
        <button onClick={handleEdit}>Edit</button>
        <button onClick={handleDelete}>Delete</button>
      </td>
    </tr>
  );
};

export default ContactRow;
