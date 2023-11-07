import { Link } from "react-router-dom";

function Header() {
  return (
    <header className="bg-clr-bg3 p-5 flex">
      <a href="#main-content" className="sr-only">
        Skip to main content
      </a>
      <Link className="select-none hover:text-clr-hover pr-10" to={"/"}>
        Order a pizza
      </Link>
      <Link className="select-none hover:text-clr-hover" to={"/orders"}>
        View orders
      </Link>
    </header>
  );
}

export default Header;
