import { Button, Checkbox, Label, Modal, Radio } from "flowbite-react";
import {
  useAddOrderMutation,
  useGetToppingsQuery,
} from "../data/redux/ApiSlice";
import { PizzaSize } from "../data/dtos/OrderResponse";
import { useForm } from "react-hook-form";
import { AddOrderRequest } from "../data/dtos/AddOrderRequest";
import { toast } from "react-toastify";
import { useEffect, useMemo } from "react";

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
    setValue,
    getValues,
    watch,
    reset,
    formState,
  } = useForm<FormProps>();

  useEffect(() => {
    const defaultValues: FormProps = {
      pizzaSize: PizzaSize.Small,
      toppingIds: [],
    };
    reset({ ...defaultValues });
  }, []);

  const calculateOrderPrice = useMemo(() => {
    const props = getValues();
    const size = props.pizzaSize;
    const toppings = props.toppingIds;
    let price = 0;

    switch (size) {
      case PizzaSize.Small:
        price += 8;
        break;
      case PizzaSize.Medium:
        price += 10;
        break;
      case PizzaSize.Large:
        price += 12;
        break;
    }

    price += toppings?.length ?? 0;

    if ((toppings?.length ?? 0) > 3) {
      price *= 0.9;
    }

    return price.toFixed(2);
  }, [watch("pizzaSize"), watch("toppingIds")]);

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
              onClick={() => setValue("pizzaSize", PizzaSize.Small)}
              className="cursor-pointer"
              id="small"
              name="size"
              value={PizzaSize.Small}
            />
            <Label className="cursor-pointer" htmlFor="small">
              Small
            </Label>
          </div>
          <div className="flex items-center gap-2">
            <Radio
              onClick={() => setValue("pizzaSize", PizzaSize.Medium)}
              className="cursor-pointer"
              id="medium"
              name="size"
              value={PizzaSize.Medium}
            />
            <Label className="cursor-pointer" htmlFor="medium">
              Medium
            </Label>
          </div>
          <div className="flex items-center gap-2">
            <Radio
              onClick={() => setValue("pizzaSize", PizzaSize.Large)}
              className="cursor-pointer"
              id="large"
              name="size"
              value={PizzaSize.Large}
            />
            <Label className="cursor-pointer" htmlFor="large">
              Large
            </Label>
          </div>
          <legend className="font-bold">
            Select toppings
            <span className="text-clr-text2 text-fs-h4 ml-3 text-clr-success">
              (10% off with 4 or more)
            </span>
          </legend>
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
      <Modal.Footer className="flex flex-row">
        <Button
          color="blue"
          className="text-clr-text1"
          onClick={handleSubmit(({ pizzaSize, toppingIds }) => {
            const request = new AddOrderRequest(pizzaId, pizzaSize, toppingIds);
            console.log(request);
            addOrder(request)
              .unwrap()
              .then(() => {
                toast.success("Order submitted successfully");
              })
              .catch(() => {
                toast.error("An error has occured");
              });
          })}
        >
          Save Order
        </Button>
        <div className="flex-1" />
        <div className="text-clr-text1 font-bold text-fs-h1 pr-10">
          Price: {calculateOrderPrice} €
        </div>
      </Modal.Footer>
    </>
  );
}

export default PizzaOrderForm;
