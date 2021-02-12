import { Home } from 'pages';
import { ImportRegions } from 'pages/Home/components/importRegions/importRegions';
export const routesList = [
  {
    path: "/",
    exact: true,
    component: ImportRegions
  },
  {
    path: "/ui",
    component: Home,
    routes: [
      {
        path: "/ui/regions/import",
        component: ImportRegions
      }
    ]
  }
];
