import { useState } from "react";
import { Pizza } from "../data/dtos/Pizza";
import PizzaOrderModal from "./PizzaOrderModal";

function PizzaCard({ pizza }: { pizza: Pizza }) {
  const [openModal, setOpenModal] = useState<boolean>(false);
  return (
    <>
      <div
        onClick={() => setOpenModal(true)}
        className="flex flex-row p-7 h-[200px] bg-clr-bg1 hover:bg-clr-bg2 cursor-pointer"
      >
        <div className="mr-5">
          <h2 className="font-bold">{pizza.name}</h2>
          <p className="line-clamp-3">{pizza.description}</p>
        </div>
        <img src="/pizza.png" className="rounded-2xl aspect-auto" />
      </div>
      <PizzaOrderModal
        openModal={openModal}
        setOpenModal={setOpenModal}
        pizza={pizza}
      />
    </>
  );
}

export default PizzaCard;
