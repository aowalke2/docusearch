import { Home } from "./components/Home";
import {Upload} from "./components/Upload";
import { Audit } from "./components/Audit";
import { DocumentList } from "./components/DocumentList";

const AppRoutes = [
  {
    index: true,
    element: <Home />
  },
  {
    path: '/upload',
    element: <Upload />
  },
  {
    path: '/document-list',
    element: <DocumentList />
  },
  {
    path: '/audit',
    element: <Audit />
  }
];

export default AppRoutes;
