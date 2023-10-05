import { Button, Checkbox, Label, Modal, Radio } from "flowbite-react";
import { Pizza } from "../data/dtos/Pizza";
import { useGetToppingsQuery } from "../data/redux/ApiSlice";
import PizzaOrderForm from "./PizzaOrderForm";

interface Props {
  openModal: boolean;
  setOpenModal: (value: React.SetStateAction<boolean>) => void;
  pizza: Pizza;
}

function PizzaOrderModal({ openModal, setOpenModal, pizza }: Props) {
  const { data: toppings } = useGetToppingsQuery(undefined);

  return (
    <>
      <Modal dismissible show={openModal} onClose={() => setOpenModal(false)}>
        <Modal.Header>
          <div className="flex flex-col cursor-pointer">
            <img src="/pizza.png" className="w-[200px] mx-auto" />
            <div className="p-5">
              <h2 className="font-bold text-fs-h1 pb-5">{pizza.name}</h2>
              <p className="line-clamp-3">{pizza.description}</p>
            </div>
          </div>
        </Modal.Header>
        <PizzaOrderForm pizzaId={pizza.id} />
      </Modal>
    </>
  );
}

export default PizzaOrderModal;
