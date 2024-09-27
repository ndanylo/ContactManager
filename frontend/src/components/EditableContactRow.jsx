import React from "react";

const EditableContactRow = ({
  newData,
  setNewData,
  handleSave,
  handleCancel,
}) => {
  return (
    <tr>
      <td>
        <input
          value={newData.name || ""}
          onChange={(e) => setNewData({ ...newData, name: e.target.value })}
        />
      </td>
      <td>
        <input
          type="date"
          value={newData.birthday ? newData.birthday.split("T")[0] : ""}
          onChange={(e) => setNewData({ ...newData, birthday: e.target.value })}
        />
      </td>
      <td>
        <input
          value={newData.phone || ""}
          onChange={(e) => setNewData({ ...newData, phone: e.target.value })}
        />
      </td>
      <td>
        <input
          type="number"
          value={newData.salary || ""}
          onChange={(e) => setNewData({ ...newData, salary: e.target.value })}
        />
      </td>
      <td>
        <select
          value={newData.marriageStatus || ""}
          onChange={(e) =>
            setNewData({ ...newData, marriageStatus: e.target.value })
          }
        >
          <option value="Single">Single</option>
          <option value="Married">Married</option>
        </select>
      </td>
      <td>
        <button onClick={handleSave}>Save</button>
        <button onClick={handleCancel}>Cancel</button>
      </td>
    </tr>
  );
};

export default EditableContactRow;
