# Ubiquitous Language

## Domain

## Core Domain
* Cultivate rich model with Ubiquitous Language

## Subdomain

* Product Catalog - use Product Catalog Context
* Customer - Customer Context
* Orders - Purchase Context
* Invoicing - Purchase Context
* Shipping - Shipping Context
* Authentication - Security Context
* Authorization - Security Context

Subdomain would have been implemented as a clean Bounded Context. There is three types of subdomains, they are:
* Core domain
* Supporting Subdomain
* Generic Subdomain

## Bounded Context
* Names enter Ubiquitous Language
* Keep model unified by Continuous Integration

A single Bounded Context does not necessarily fall within only a single Subdomain,
but it may. - Vaughn


### Generic Subdomains
* Avoid overinvesting in subdomains

# Context Map

* Product Catalog Context
* Purchase Context
* Shipping Context
* Security Context
* Customer Context

![Working in Progress](https://drive.google.com/file/d/1WgBmGfj-PEgW3yDOwXSM-7N3ZGbnfdW6/view?usp=sharing)


## Big Ball of Mud
* Segregate the conceptual messes

## Anti-Corruption Layer
* Translate and insulate uniterally

## Published Language
* loosely couple context through published language
* Formalize the open host service

## Open Host Service
* support multiple client through open host service

## Conformist 
* minimize Translations

## Customer / Supplier
* Relate allied contexts as Customer / Supplier


## Shared Kernel

* Overlap allied context through
* interdependent context form

# Model-Driven Design
* Define model within [Bounded Context](#bounded-context)
* model gives structure to [Ubiquitous Language](#ubiquitous-language)
* express model with [Services](#services)
* express change with [Domain Events](#domain-events)
* express identity with [Entities](#entities)
* express state and computation with [Value Objects](#value-objects)
* isolate domain expressions with [Layered Architecture](#layered-architecture)

## Services

## Domain Events

## Entities
* push state change with [Domain Events](#domain-events)
* access with [Repositories](#repositories)
* encapsulate with [Aggregates](#aggregates)
* act as root of [Aggregates](#aggregates)
* encapsulate with [Factories](#factories)

## Value Objects
* Encapsulate with [Factories](#factories)
* encapsulate with [Aggregates](#aggregates)

## Factories

Factories sometimes are used as Factory Methods, so the static factory method let us get an Association without instantiating it directly.
It returns the association instance we want.
E.g.
```
var association = Association.Create(parameters)
```

Factory methods help to avoid entities being in an inconsistent state.

> Steve Smith - [Twitter](https://twitter.com/ardalis)

## Layered Architecture

## Repositories

## Aggregates
* access with [Repositories](#repositories)



