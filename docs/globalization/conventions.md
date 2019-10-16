# Globalization conventions

### Message Codes

The platform must be have the capability to support a lot of languages. The backend must be return all messages with the language that requester sended.

To provide this capability, we will use a message code convention with the following example:

<b>PRODUCT-BOUNDEDCONTEXT-LAYER-SUBLAYER-CODE</b> (e.g. DOUTOVILHA-CORE-SERVICE-GATEWAY-1)

The message code have:

| Section | Description |
|---|---|
| <b>PRODUCT</b> | The product name |
| <b>BOUNDEDCONTEXT</b> | The bounded context name |
| <b>LAYER</b> | The first-level layer |
| <b>SUBLAYER</b> | The second-level layer |
| <b>CODE</b> | Sequential numeric number |
