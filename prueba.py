import random

# Lista de nombres aleatorios
nombres = ["Pepito Perez", "Juan Rodriguez", "Maria Garcia", "Luis Hernandez", "Ana Martinez", "Carlos Sanchez"]

# Lista de tipos de solicitud
tipos_solicitud = ["GC-100", "GC-200", "GC-300", "GC-400", "GC-500"]

# Generar 10 registros en HTML
for _ in range(10):
    tipo_solicitud = random.choice(tipos_solicitud)
    tiempo_espera = f"{random.randint(1, 60)} MIN"
    nombre_completo = random.choice(nombres)
    documento = f"CC {random.randint(1000000, 9999999)}"
    
    # Imprimir registro HTML
    print(f"""
    <tr>
        <th scope="row">{tipo_solicitud}</th>
        <td>{tiempo_espera}</td>
        <td>{nombre_completo}</td>
        <td>{documento}</td>
        <td>
            <div class="btn-group" role="group" aria-label="Basic outlined example">
                <button type="button" class="btn btn-outline-primary">Llamar</button>
                <button type="button" class="btn btn-outline-primary">Pasar</button>
                <button type="button" class="btn btn-outline-primary">Borrar</button>
            </div>
        </td>
    </tr>
    """)
