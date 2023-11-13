# Toppings Controller Reference

## Introduction
This document outlines the usage of the Toppings Controller, which can be used to get available toppings

## Endpoints


### Get Toppings List
- **URL:** `/api/toppings`
- **Method:** `GET`
- **Request Parameters:** `-`
- **Response Type:** 
```javasript
{
    "id": int,
    "name": string,
}
```
- **Sample Request:** `GET /api/toppings`
- **Sample Response:** 
```json
[
    {
        "id": 1,
        "name": "Mozzarella"
    },
    {
        "id": 2,
        "name": "Pickled bulbs"
    },
    {
        "id": 3,
        "name": "Pickled cucumbers"
    },
    {
        "id": 4,
        "name": "Pineapple"
    }, 
]
```