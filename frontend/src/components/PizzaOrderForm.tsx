import { Button, Checkbox, Label, Modal, Radio } from "flowbite-react";
import {
  useAddOrderMutation,
  useGetToppingsQuery,
} from "../data/redux/ApiSlice";
import { PizzaSize } from "../data/dtos/OrderResponse";
import { useForm } from "react-hook-form";
import { AddOrderRequest } from "../data/dtos/AddOrderRequest";

interface FormProps {
  pizzaSize: PizzaSize;
  toppingIds: [];
}

function PizzaOrderForm({ pizzaId }: { pizzaId: number }) {
  const { data: toppings } = useGetToppingsQuery(undefined);
  const [addOrder] = useAddOrderMutation();
  const {
    register,
    handleSubmit,
    reset,
    formState: { errors },
  } = useForm<FormProps>();
  return (
    <>
      <Modal.Body>
        <fieldset
          className="flex max-w-md flex-col gap-4 text-clr-text1 select-none"
          id="radio"
        >
          <legend className="mb-4 font-bold">Select the pizza size</legend>
          <div className="flex items-center gap-2">
            <Radio
              defaultChecked
              {...register("pizzaSize")}
              className="cursor-pointer"
              id="small"
              name="size"
              value={1}
            />
            <Label className="cursor-pointer" htmlFor="small">
              Small
            </Label>
          </div>
          <div className="flex items-center gap-2">
            <Radio
              {...register("pizzaSize")}
              className="cursor-pointer"
              id="medium"
              name="size"
              value={2}
            />
            <Label className="cursor-pointer" htmlFor="medium">
              Medium
            </Label>
          </div>
          <div className="flex items-center gap-2">
            <Radio
              {...register("pizzaSize")}
              className="cursor-pointer"
              id="large"
              name="size"
              value={3}
            />
            <Label className="cursor-pointer" htmlFor="large">
              Large
            </Label>
          </div>
          <legend className="mb-4 font-bold">Select toppings</legend>
          {toppings?.map((x) => (
            <div key={x.id} className="flex items-center gap-2">
              <Checkbox
                {...register("toppingIds")}
                className="cursor-pointer"
                id={x.id.toString()}
                value={x.id}
              />
              <Label className="cursor-pointer" htmlFor={x.id.toString()}>
                {x.name}
              </Label>
            </div>
          ))}
        </fieldset>
      </Modal.Body>
      <Modal.Footer>
        <Button
          color="blue"
          className="text-clr-text1"
          onClick={handleSubmit(({ pizzaSize, toppingIds }) => {
            const request = new AddOrderRequest(pizzaId, pizzaSize, toppingIds);
            console.log(request);
            addOrder(request);
          })}
        >
          Order
        </Button>
      </Modal.Footer>
    </>
  );
}

export default PizzaOrderForm;
