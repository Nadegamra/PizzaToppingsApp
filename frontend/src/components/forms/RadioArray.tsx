import { Label, Radio } from "flowbite-react";
import { forwardRef } from "react";

export interface RadioItem {
  label: string;
  value: unknown;
  setValue: () => void;
}

interface Props {
  headerText: string;
  defaultValue: unknown;
  radioItems: RadioItem[];
  [x: string]: unknown;
}

const RadioArray = forwardRef<HTMLInputElement, Props>(
  ({ headerText, defaultValue, radioItems, ...rest }, ref) => {
    return (
      <>
        <legend className="mb-4 font-bold">{headerText}</legend>
        {radioItems.map(({ label, value, setValue }) => (
          <>
            <div className="flex items-center gap-2">
              <Radio
                defaultChecked={value === defaultValue}
                onClick={setValue}
                className="cursor-pointer"
                id="small"
                name="size"
                ref={ref}
                {...rest}
              />
              <Label className="cursor-pointer" htmlFor="small">
                {label}
              </Label>
            </div>
          </>
        ))}
      </>
    );
  }
);

export default RadioArray;
