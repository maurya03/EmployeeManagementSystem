import React, { useEffect, useState } from 'react';
import EmployeeService from './services/EmployeeService';

const EmployeeManagementSystem = () => {
  const [employees, setEmployees] = useState([]);

  const fetchEmployees = async () => {
    const { data } = await EmployeeService.getAllEmployees();
    setEmployees(data);
  };

  useEffect(() => {
    fetchEmployees();
  }, []);

  const deleteEmployee = async (id) => {
    await EmployeeService.deleteEmployee(id);
    fetchEmployees();
  };

  return (
    <div>
      <h1>Employee Management System</h1>
      <ul>
        {employees.map((employee) => (
          <li key={employee.id}>
            {employee.name} - {employee.department}
            <button onClick={() => deleteEmployee(employee.id)}>Delete</button>
          </li>
        ))}
      </ul>
    </div>
  );
};

export default EmployeeManagementSystem;
