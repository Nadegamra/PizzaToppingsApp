import { useState } from "react";
import { Pizza } from "../../data/dtos/Pizza";
import PizzaOrderModal from "./PizzaOrderModal";

function PizzaCard({ pizza }: { pizza: Pizza }) {
  const [openModal, setOpenModal] = useState<boolean>(false);
  return (
    <>
      <div
        onClick={() => setOpenModal(true)}
        className="h-[200px] flex flex-row items-center p-7 bg-clr-bg1 hover:bg-clr-bg2 cursor-pointer"
      >
        <div className="mr-5 flex-1">
          <h2 className="font-bold text-fs-h2">{pizza.name}</h2>
          <p className="line-clamp-3">{pizza.description}</p>
        </div>
        <img
          src="/pizza.png"
          className="rounded-2xl aspect-auto h-[200px] py-5"
        />
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
