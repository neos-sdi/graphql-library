export interface Book{
  id: string
  title: string
}

export interface AddBookCommandInput{
  title: string
  description?: string
}
