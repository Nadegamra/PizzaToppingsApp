import { ReactNode } from "react";

function CardHeader({ children }: { children: ReactNode }) {
  return <h1 className="font-bold px-5 pb-5 text-fs-h1">{children}</h1>;
}

export default CardHeader;
