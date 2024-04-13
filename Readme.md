# DevInterview - Software Guidebook

## Introduction

This software guidebook provides an overview of the **DevInterview** platform. It includes a summary of the following:

- The requirements, constraints and principles behind the solution.
- The software architecture, including the high-level technology choices and structure of the software.
- The infrastructure architecture and how the software is deployed.
- Operational and support aspects of the application.

See how it works with a hands on demo.

- Mobile App: https://www.demo.com
- SPA Web App: https://www.demo.com
- Admin Panel: https://www.demo.com

## Context

**DevInterview** is a platform designed to assist software developers in preparing for technical interviews or certification exams through questions with respective detailed answers.

### Users

The platform has three types of user:

- **Anonymous**: Anybody with a web browser o smartphone can view free content on the platform.
- **Authenticated**:
- **Admin**: People with administrative (super-user) access to the platform can manage the content that is aggregated into the platform.

### External Systems

There are three types of systems that DevInterview integrates with.

- ChatGPT

## Functional Overview

abc

## Quality Attributes

abc

## Constraints

abc

## Principles

abc

## Software Architecture

![](docs/images/containers.png)

- **Admin Panel**: An admin panel serves as a user-friendly control center to maintain various aspects of your web application like managing and organising content, tracking website analytics, managing user accounts, and performing various other tasks.
- **Web-DevInterview API Gateway**: abc
- **Mobile-DevInterview API Gateway**: abc
- **Identity Service**: abc
- **Catalog Service**: abc

## Infrastructure Architecture

abc

## Deployment

abc

## Development

```
docker-compose -f docker-compose.yml -f docker-compose.override.yml up -d
```

Get data with Cloud Firestore
https://firebase.google.com/docs/firestore/query-data/get-data#c

Upload Files Firebase Storage:

- Install FirebaseStore.net
- Activar servicio Storage en Firebase
- Get the "Folder Path" --> gs://devinterview-2aedb.appspot.com and set variable "Bucket"
- Get the "Web Api Key" --> Project Settings
- Create user for authentication: uploadfiles@devinterview.com
- Change Storage Rules: allow read, write: if request.auth != null;
- https://www.youtube.com/watch?v=tDBqEimGcDo
  https://dev.to/airarrazabald/conectando-api-en-net-5-con-firebase-storage-2fhk
