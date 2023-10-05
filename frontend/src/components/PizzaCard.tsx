import { useState } from "react";
import { Pizza } from "../data/dtos/Pizza";
import { Button, Checkbox, Label, Modal, Radio } from "flowbite-react";
import { useGetToppingsQuery } from "../data/redux/ApiSlice";

function PizzaCard({ pizza }: { pizza: Pizza }) {
  const [openModal, setOpenModal] = useState<boolean>(false);
  const { data: toppings } = useGetToppingsQuery(undefined);
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
        <Modal.Body>
          <fieldset
            className="flex max-w-md flex-col gap-4 text-clr-text1 select-none"
            id="radio"
          >
            <legend className="mb-4 font-bold">Select the pizza size</legend>
            <div className="flex items-center gap-2">
              <Radio
                className="cursor-pointer"
                defaultChecked
                id="small"
                name="size"
                value="1"
              />
              <Label className="cursor-pointer" htmlFor="small">
                Small
              </Label>
            </div>
            <div className="flex items-center gap-2">
              <Radio
                className="cursor-pointer"
                id="medium"
                name="size"
                value="2"
              />
              <Label className="cursor-pointer" htmlFor="medium">
                Medium
              </Label>
            </div>
            <div className="flex items-center gap-2">
              <Radio
                className="cursor-pointer"
                id="large"
                name="size"
                value="3"
              />
              <Label className="cursor-pointer" htmlFor="large">
                Large
              </Label>
            </div>
            <legend className="mb-4 font-bold">Select toppings</legend>
            {toppings?.map((x) => (
              <div className="flex items-center gap-2">
                <Checkbox className="cursor-pointer" id={x.id.toString()} />
                <Label className="cursor-pointer" htmlFor={x.id.toString()}>
                  {x.name}
                </Label>
              </div>
            ))}
          </fieldset>
        </Modal.Body>
        <Modal.Footer>
          <Button color="blue" className="text-clr-text1">
            Order
          </Button>
        </Modal.Footer>
      </Modal>
    </>
  );
}

export default PizzaCard;
