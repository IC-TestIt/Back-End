# API Documentation

## Teacher's Methods

**GetTeacherTests**

   Return jason data with Teacher's tests

   * **URL**

     /api/teacher/{id}/tests

   * **Method:**

     `GET`
  
   * **Data Params**

      None

   * **Success Response:**

     * **Code:** 200 <br />
     **Content:** `{ "id": 1, "title": "P1 ALOG", "description": "Prova 1 de Algoritmo" }`
 
    * **Error Response:**

      * **Code:** 404 NOT FOUND <br />
---
**GetTeacherClasses**

   Return jason data with Teacher's Classes

   * **URL**

     /api/teacher/{id}/classes

   * **Method:**

     `GET`
  
   * **Data Params**

      None

   * **Success Response:**

     * **Code:** 200 <br />
     **Content:** `{ "description": "BD - Noite", "id": 1 }`
 
    * **Error Response:**

      * **Code:** 404 NOT FOUND <br />
---
## Student's Methods

**StudentExists**

   Return Student's id if he exists

   * **URL**

     /api/student/exists/{email}

   * **Method:**

     `GET`
  
   * **Data Params**

      None

   * **Success Response:**

     * **Code:** 200 <br />
     **Content:** `{ "id": 1}`
 
    * **Error Response:**

      * **Code:** 200 <br />
     **Content:** `{ -1 }`
      
 
