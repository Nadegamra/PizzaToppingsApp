# Pizzas Controller Reference

## Introduction
This document outlines the usage of the Pizza Controller, which can be used to get available pizzas

## Endpoints


### Get Pizzas List
- **URL:** `/api/pizzas`
- **Method:** `GET`
- **Request Parameters:** `-`
- **Response Type:** 
```javasript
{
    "id": int,
    "name": string,
    "description": string
}
```
- **Sample Request:** `GET /api/pizzas`
- **Sample Response:** 
```json
[
    {
        "id": 1,
        "name": "Brooklyn",
        "description": "Italian tomato sauce, chicken, ham, salami, smoked beef, peppers, pepperoni peppers, cheese stew, basil"
    },
    {
        "id": 2,
        "name": "Capricciosa",
        "description": "Italian tomato sauce, ham, mushrooms, olives, cheese sauce, basil"
    },
]
```