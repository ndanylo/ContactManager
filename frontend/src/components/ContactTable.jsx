import React, { useEffect, useState } from "react";
import apiService from "../services/apiService";
import FilterInput from "./FilterInput";
import SortHeader from "./SortHeader";
import ContactRow from "./ContactRow";
import EditableContactRow from "./EditableContactRow";

const ContactTable = () => {
  const [contacts, setContacts] = useState([]);
  const [filteredContacts, setFilteredContacts] = useState([]);
  const [loading, setLoading] = useState(true);
  const [sortConfig, setSortConfig] = useState({
    key: "name",
    direction: "ascending",
  });
  const [editableRow, setEditableRow] = useState(null);
  const [newData, setNewData] = useState({});
  const [filterText, setFilterText] = useState("");
  const [file, setFile] = useState(null);

  useEffect(() => {
    fetchContacts();
  }, []);

  useEffect(() => {
    setFilteredContacts(contacts);
  }, [contacts]);

  useEffect(() => {
    if (filterText) {
      const lowerCaseFilter = filterText.toLowerCase();
      const filtered = contacts.filter((contact) =>
        Object.values(contact).some((value) =>
          String(value).toLowerCase().includes(lowerCaseFilter)
        )
      );
      setFilteredContacts(filtered);
    } else {
      setFilteredContacts(contacts);
    }
  }, [filterText, contacts]);

  const fetchContacts = async () => {
    try {
      const contacts = await apiService.getAllContacts();
      setContacts(contacts);
    } catch (error) {
      console.error("Failed to fetch contacts:", error);
    } finally {
      setLoading(false);
    }
  };

  const handleSort = (key) => {
    let direction = "ascending";
    if (sortConfig.key === key && sortConfig.direction === "ascending") {
      direction = "descending";
    }
    const sortedContacts = [...filteredContacts].sort((a, b) => {
      if (a[key] < b[key]) return direction === "ascending" ? -1 : 1;
      if (a[key] > b[key]) return direction === "ascending" ? 1 : -1;
      return 0;
    });
    setSortConfig({ key, direction });
    setFilteredContacts(sortedContacts);
  };

  const handleSave = async (contact) => {
    if (
      !newData.name ||
      !newData.phone ||
      !newData.birthday ||
      !newData.salary ||
      !newData.isMarried
    ) {
      console.log(newData);
      alert("Please fill in all fields.");
      return;
    }

    const updatedContact = {
      ...newData,
      isMarried: newData.marriageStatus === "Married",
    };

    try {
      console.log(updatedContact);
      await apiService.updateContact({ ...updatedContact, id: contact.id });
      setContacts((prevContacts) =>
        prevContacts.map((c) => (c.id === contact.id ? updatedContact : c))
      );
      setEditableRow(null);
    } catch (error) {
      console.error("Failed to save contact:", error);
    }
  };

  const handleDelete = async (id) => {
    if (window.confirm("Are you sure you want to delete this contact?")) {
      try {
        await apiService.deleteContact(id);
        setContacts((prevContacts) => prevContacts.filter((c) => c.id !== id));
      } catch (error) {
        console.error("Failed to delete contact:", error);
      }
    }
  };

  const handleEdit = (contact) => {
    setNewData(contact);
    setEditableRow(contact.id);
  };

  const handleFileChange = (e) => {
    setFile(e.target.files[0]);
  };

  const handleFileUpload = async () => {
    if (!file) {
      alert("Please select a file first.");
      return;
    }

    const formData = new FormData();
    formData.append("file", file);

    try {
      await apiService.uploadCsv(formData);
      fetchContacts();
      alert("Contacts were uploaded successfully.");
    } catch (error) {
      console.error("Failed to upload contacts:", error);
      alert("Error occured while uploading contacts.");
    }
  };

  if (loading) return <div>Loading...</div>;

  return (
    <div>
      <h1>Contact List</h1>
      <FilterInput filterText={filterText} onFilterChange={setFilterText} />
      <div>
        <input type="file" accept=".csv" onChange={handleFileChange} />
        <button onClick={handleFileUpload}>Upload CSV</button>
      </div>

      <table>
        <thead>
          <tr>
            <SortHeader label="Name" onSort={() => handleSort("name")} />
            <SortHeader
              label="Birthday"
              onSort={() => handleSort("birthday")}
            />
            <SortHeader label="Phone" onSort={() => handleSort("phone")} />
            <SortHeader label="Salary" onSort={() => handleSort("salary")} />
            <SortHeader
              label="Marriage Status"
              onSort={() => handleSort("marriageStatus")}
            />
            <th>Actions</th>
          </tr>
        </thead>
        <tbody>
          {filteredContacts.length === 0 ? (
            <tr>
              <td colSpan="6">No contacts found.</td>
            </tr>
          ) : (
            filteredContacts.map((contact) =>
              editableRow === contact.id ? (
                <EditableContactRow
                  key={contact.id}
                  newData={newData}
                  setNewData={setNewData}
                  handleSave={() => handleSave(contact)}
                  handleCancel={() => setEditableRow(null)}
                />
              ) : (
                <ContactRow
                  key={contact.id}
                  contact={contact}
                  handleEdit={() => handleEdit(contact)}
                  handleDelete={() => handleDelete(contact.id)}
                />
              )
            )
          )}
        </tbody>
      </table>
    </div>
  );
};

export default ContactTable;
