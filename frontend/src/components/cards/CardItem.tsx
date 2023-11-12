import React, { ReactNode } from "react";

function CardItem({ children, id }: { children: ReactNode; id: number }) {
  return (
    <React.Fragment key={id}>
      <hr className="mx-5 border-t-[3px]" />
      {children}
    </React.Fragment>
  );
}

export default CardItem;
