import { ReactNode } from "react";

function Card({ children }: { children: ReactNode[] }) {
  return (
    <section className="bg-clr-bg1 w-[500px] mx-auto rounded-2xl my-10 py-5">
      {children}
    </section>
  );
}

export default Card;
