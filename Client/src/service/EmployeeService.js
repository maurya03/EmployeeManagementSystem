import axios from 'axios';

const API_URL = 'http://localhost:5089/api/employee';

class EmployeeService {
  static getAllEmployees() {
    return axios.get(`${API_URL}/"GetAllEmployee"`);
  }

  static getEmployeeById(id) {
    return axios.get(`${API_URL}/'GetEmployeeById'/${id}`);
  }

  static addEmployee(employee) {
    return axios.post(`${API_URL}/'AddEmployee'`, employee);
  }

  static updateEmployee(id, employee) {
    return axios.put(`${API_URL}/'UpdateEmployee'/${id}`, employee);
  }

  static deleteEmployee(id) {
    return axios.delete(`${API_URL}/'DeleteEmployee'/${id}`);
  }
}

export default EmployeeService;
