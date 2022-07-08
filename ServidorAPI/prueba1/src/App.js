
import './App.css';

import {Tienda} from './Tienda'
import {Categoria} from './Categoria'
import {Producto} from './Producto'
import {Venta} from './Venta'
import { Departamento } from './Departamento';

import {BrowserRouter, Route, Routes,NavLink} from 'react-router-dom';


function App() {
  return (
    <BrowserRouter>
    <div className="Appcontainer">
      
      <nav className="navbar navbar-expand-sm bg-dark rounded navbar-dark justify-content-center">
        <label for="" className="brand">
          <a><img src="CaprichoLogo.svg" width="100" height="100" className=""/></a> 
          </label>

        <ul className="navbar-nav">
          <li className="nav-item-  m-1">
            <NavLink className="btn btn-light btn-outline-secundary  m-1" to="/tienda">
              Tienda
            </NavLink>
            <NavLink className="btn btn-light btn-outline-secundary m-1" to="/categoria">
              Categoria
            </NavLink>
            <NavLink className="btn btn-light btn-outline-secundary m-1" to="/producto">
              Producto
            </NavLink>
            <NavLink className="btn btn-light btn-outline-secundary m-1" to="/venta">
              Ventas
            </NavLink>
            <NavLink className="btn btn-light btn-outline-secundary m-1" to="/departamento">
              Departamentos
            </NavLink>
          </li>
        </ul>
      </nav>
      <Routes>
        <Route path='/tienda' element={<Tienda/>}/>
        <Route path='/categoria' element={<Categoria/>}/>
        <Route path='/producto' element={<Producto/>}/>
        <Route path='/venta' element={<Venta/>}/>
        <Route path='/departamento' element={<Departamento/>}/>
      </Routes>
    </div>
    </BrowserRouter>
  );
}

export default App;
