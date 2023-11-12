import { Button, Checkbox, Label, Modal, Radio } from "flowbite-react";

import { useForm } from "react-hook-form";
import { toast } from "react-toastify";
import { useEffect, useMemo } from "react";
import { PizzaSize } from "../../data/dtos/OrderResponse";
import { AddOrderRequest } from "../../data/dtos/AddOrderRequest";
import { useAddOrderMutation } from "../../data/features/ApiSliceOrders";
import { useGetToppingsQuery } from "../../data/features/ApiSliceToppings";
import RadioArray, { RadioItem } from "./RadioArray";

interface FormProps {
  pizzaSize: PizzaSize;
  toppingIds: [];
}

function PizzaOrderForm({ pizzaId }: { pizzaId: number }) {
  const { data: toppings } = useGetToppingsQuery(undefined);
  const [addOrder] = useAddOrderMutation();
  const { register, handleSubmit, setValue, getValues, watch, reset } =
    useForm<FormProps>();

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

  const radios: RadioItem[] = [
    {
      label: "Small",
      setValue: () => setValue("pizzaSize", PizzaSize.Small),
      value: PizzaSize.Small,
    },
    {
      label: "Medium",
      setValue: () => setValue("pizzaSize", PizzaSize.Medium),
      value: PizzaSize.Medium,
    },
    {
      label: "Large",
      setValue: () => setValue("pizzaSize", PizzaSize.Large),
      value: PizzaSize.Large,
    },
  ];

  return (
    <>
      <Modal.Body>
        <fieldset
          className="flex max-w-md flex-col gap-4 text-clr-text1 select-none"
          id="radio"
        >
          <RadioArray
            headerText="Select the pizza size"
            defaultValue={PizzaSize.Small}
            radioItems={radios}
          />
          <legend className="font-bold">
            Select toppings
            <span className="text-clr-text2 text-fs-h4 ml-3">
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
