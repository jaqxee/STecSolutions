# Matriz de Pruebas Funcionales (RF-04) - STecSolutions
**Proyecto:** Sistema de Gestión de Inventario Informático  
**Fecha de Ejecución:** Octubre 2026  
**Estado General:** exitoso

---

## 1. Módulo de Administración de Inventario (RF-02 / RF-03)

### CP-01: Registro de un Activo Tecnológico Válido (Flujo Normal)
* **Descripción:** Verificar que el sistema permita almacenar un nuevo equipo en PostgreSQL cuando todos los campos son ingresados correctamente.
* **Precondiciones:** El sistema está conectado a la base de datos y existen usuarios y ubicaciones registrados en el sistema.
* **Pasos de Ejecución:**
  1. Presionar el botón verde **"Registrar Equipo"** en la ventana principal.
  2. En la pantalla emergente, seleccionar Tipo de Equipo: `"De Escritorio"`.
  3. Seleccionar Responsable: `"Alberto Oses"`.
  4. Seleccionar Ubicación: `"Concepción"`.
  5. Ingresar Número de Serie: `"STEC-777-XYZ"`.
  6. Seleccionar Estado: `"Operativo"`.
  7. Presionar el botón **"Registrar"**.
* **Resultado Esperado:** Se despliega un `MessageBox` con el mensaje de éxito, la ventana emergente se cierra automáticamente y el nuevo equipo aparece listado inmediatamente en la grilla principal (`DataGrid`) con su ID oculto.
* **Estado:** **exitoso**

### CP-02: Validación de Campos Obligatorios Vacíos (Flujo Alterno)
* **Descripción:** Validar que la aduana de seguridad bloquee el registro si faltan datos obligatorios.
* **Pasos de Ejecución:**
  1. Presionar el botón verde **"Registrar Equipo"**.
  2. Dejar la caja de texto **"Nro. Serie"** vacía.
  3. Completar el resto de los ComboBoxes con datos válidos.
  4. Presionar el botón **"Registrar"**.
* **Resultado Esperado:** El método `ValidarCampos()` intercepta la omisión, detiene la ejecución con un `return;` y muestra un `MessageBox.Show` de advertencia indicando: `"Por favor ingrese el numero de serie del equipo."`. No se genera ninguna consulta hacia PostgreSQL.
* **Estado:** **exitoso**

### CP-03: Actualización Completa de un Activo (Flujo Normal)
* **Descripción:** Verificar el correcto funcionamiento del motor híbrido al modificar los datos de un activo existente mediante su PK oculta.
* **Precondiciones:** Debe existir al menos un equipo listado en el `DataGrid`.
* **Pasos de Ejecución:**
  1. Seleccionar un equipo de la lista en la ventana principal (ej: Nro. Serie `"10-10-10"`).
  2. Presionar el botón verde claro **"Actualizar Equipo"**.
  3. Validar que la ventana abra con el título `"Actualizar Registro"`, el botón mutado a verde lima con el texto `"Guardar Cambios"`, y las cajas pre-rellenadas de la RAM.
  4. Cambiar el Responsable a `"Andrés Pérez"` y la Ubicación a `"Santiago"`.
  5. Presionar **"Guardar Cambios"**.
* **Resultado Esperado:** El programa traduce los nombres a IDs numéricos mediante `ExecuteScalar()`, ejecuta la sentencia `UPDATE equipos SET ... WHERE id_equipo = @id_equipo;` usando el bolsillo privado `_idEquipoAActualizar`, arroja confirmación de éxito y refresca la grilla principal.
* **Estado:** **exitoso**

### CP-04: Consulta Ficha Técnica de Solo Lectura (Flujo Normal)
* **Descripción:** Validar que el tercer estado del `enum` configure la pantalla en modo consulta bloqueada.
* **Pasos de Ejecución:**
  1. Seleccionar una fila del `DataGrid`.
  2. Presionar el botón gris **"Consultar Equipo"**.
  3. Intentar desplegar los ComboBoxes o escribir en el Número de Serie.
* **Resultado Esperado:** La ventana abre bajo el título `"Ficha Técnica"`. Todos los controles visuales tienen aplicados el candado lógico `IsHitTestVisible = false`, el botón de acción fue removido de la vista (`Visibility.Collapsed`) y la información se presenta de manera limpia y ordenada como solo lectura.
* **Estado:** **exitoso**

### CP-05: Cancelación de Eliminación de Activo (Flujo Alterno)
* **Descripción:** Verificar que el cuadro de diálogo estético de eliminación respete la decisión del usuario si este cancela la operación.
* **Pasos de Ejecución:**
  1. Seleccionar un equipo de la lista.
  2. Presionar el botón rojo **"Eliminar Equipo"**.
  3. En la ventana emergente adaptativa, presionar el botón gris **"Cancelar"**.
* **Resultado Esperado:** La ventana de confirmación se cierra sin ejecutar comandos, y el registro permanece intacto tanto en la interfaz gráfica como en PostgreSQL.
* **Estado:** **exitoso**

---

## 2. Resumen Ejecutivo de Validación

| ID de Prueba | Requerimiento Asociado | Componente Evaluado | Tipo de Flujo | Resultado |
| :--- | :--- | :--- | :--- | :--- |
| **CP-01** | RF-02 / RF-03 | `VentanaAgregar` (INSERT) | Normal | **exitoso** |
| **CP-02** | RF-02 (Validación) | Método `ValidarCampos()` | Alterno | **exitoso** |
| **CP-03** | RF-02 / RF-03 | Motor Híbrido (UPDATE) | Normal | **exitoso** |
| **CP-04** | RF-02 (Lectura) | `ModoPantalla.Consultar` | Normal | **exitoso** |
| **CP-05** | RF-02 / RF-02 | `VentanaEliminar` | Alterno | **exitoso** |
