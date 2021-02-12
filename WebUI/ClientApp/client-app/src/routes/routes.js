import React from "react";
import { Switch } from "react-router-dom";
import { routesList } from './routesList';
import RouteWithSubRoutes from "./routeWithSubRoutes";

export default function Routes() {
  return (
    <Switch>
          {routesList.map((route, i) => (
            <RouteWithSubRoutes key={i} {...route} />
          ))}
        </Switch>
  );
}
