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
---
**GetStudentExams**

   Return jason data with Student's Exams

   * **URL**

     /api/student/{id}/exams

   * **Method:**

     `GET`
  
   * **Data Params**

      None

   * **Success Response:**

     * **Code:** 200 <br />
     **Content:** `{ "examId": "1", "Title": "P1 Alog", "Description": " Algoritmos", "status": "1", "totalGrade":"10" }`
 
    * **Error Response:**

      * **Code:** 404 NOT FOUND <br />
---     
**GetStudentTests**

   Return jason data with Student's Tests

   * **URL**

     /api/student/{id}/tests

   * **Method:**

     `GET`
  
   * **Data Params**

      None

   * **Success Response:**

     * **Code:** 200 <br />
     **Content:** `{
      "name": "alog",
      "className": "alog",
      "teacherName": "medson",
      "endDate": "2017-10-30T00:00:00",
      "classTestId": 3
      }`
 
    * **Error Response:**

      * **Code:** 404 NOT FOUND <br />
 ---     
 ## User's Methods
 
 **GetUsers**

   Return jason data with Users

   * **URL**

     /api/user

   * **Method:**

     `GET`
  
   * **Data Params**

      None

   * **Success Response:**

     * **Code:** 200 <br />
     **Content:** `{
      "name": "dimas",
      "email": "dimasoprimeiro@",
      "phone": "12345678",
      "identifier": "Professor"
      },
      {
      "name": "Cesar",
      "email": "cesar@gmail.com",
      "phone": "12345678",
      "identifier": "Professor"
      }`
 
    * **Error Response:**

      * **Code:** 404 NOT FOUND <br />
---
 **GetUser**

   Return jason data with one User

   * **URL**

     /api/user/{id}

   * **Method:**

     `GET`
  
   * **Data Params**

      None

   * **Success Response:**

     * **Code:** 200 <br />
     **Content:** `{
      "name": "dimas",
      "email": "dimasoprimeiro@",
      "phone": "12345678",
      "identifier": "Professor"
      },`
 
    * **Error Response:**

      * **Code:** 404 NOT FOUND <br />
---
      
 
