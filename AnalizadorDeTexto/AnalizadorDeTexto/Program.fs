 open System 
open System.Text.RegularExpressions

// Analizador de texto en F# 

// funcion para contar las palabras en un texto 

let contarPalabras (texto: string) =
    let palabras = Regex.Matches(texto, @"\w+") 
    palabras.Count  
  
// funcion para contar las lineas de un texto 

let contarLineas (texto: string) =
    texto.Split('\n') |> Array.length

// funcio para contar el total de letras en un texto 

let contarLetras (texto: string) =
    texto |> Seq.filter Char.IsLetter |> Seq.length 

// funcion para calcular la frecuencia de cada palabra en un texto 

let frecuenciaPalabra (texto: string) =
     texto.ToLower()  
    |> fun lowerText -> Regex.Matches(lowerText, @"\w+")  
    |> Seq.cast<Match>  
    |> Seq.map (fun m -> m.Value)  
    |> Seq.groupBy id  
    |> Seq.map (fun (word, occurrences) -> word, Seq.length occurrences)  
    |> Map.ofSeq  

 // Función para mostrar todas las estadísticas

let mostrarEstadisticas (texto: string) =
    printfn "Analisis del texto:"
    printfn "Numero de palabras: %d" (contarPalabras texto)
    printfn "Numero de lineas: %d" (contarLineas texto)
    printfn "Numero de letras: %d" (contarLetras texto)
    printfn "Frecuencia de palabras:"
    frecuenciaPalabra texto
    |> Map.iter (fun word freq -> printfn "Palabra '%s' -> %d veces" word freq)

// Texto de prueba

let introducirTexto = """F# es un lenguaje funcional. F# permite la inmutabilidad y el uso de funciones puras.
Este texto sirve para demostrar el analizador de texto en F#."""

// Llamar a la función para mostrar estadísticas

mostrarEstadisticas introducirTexto 