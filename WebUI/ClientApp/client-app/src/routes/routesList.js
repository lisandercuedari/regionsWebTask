import { Home } from 'pages';
import { GetEmployees } from 'pages/Home/components/importRegions/getEmployees';
export const routesList = [
  {
    path: "/ui",
    component: Home,
    routes: [
      {
        path: "/ui/regions/employees",
        component: GetEmployees
      }
    ]
  }
];
