import PersonForm from "./PersonForm"
import PersonList from "./PersonList"

function Person() {
    const people = [
      { id: 1, firstName: "Alice", lastName: "Johnson" },
      { id: 2, firstName: "Bob", lastName: "Smith" },
      { id: 3, firstName: "Charlie", lastName: "Lee" },
      { id: 4, firstName: "Diana", lastName: "Patel" },
      { id: 5, firstName: "Ethan", lastName: "Brown" }
    ];

    const handlePersonEdit = (person) => {
        console.log("Edit person:", person);
    }

    const handlePersonDelete = (person) => {
        if(! confirm(`Are you sure you want to delete ${person.firstName} ${person.lastName}?`)) {
            return;
        }
        console.log("Delete person:", person);
    }

    return (
        <div className="min-h-screen bg-gray-50 py-8">
            <div className="max-w-4xl mx-auto px-4 sm:px-6 lg:px-8 space-y-6">
                <div className="text-center mb-8">
                    <h1 className="text-3xl font-bold bg-gradient-to-r from-blue-600 to-purple-600 bg-clip-text text-transparent">
                        Person Management
                    </h1>

                </div>                                            

                <PersonForm />
                <PersonList peopleList={people} onPersonEdit={handlePersonEdit} onPersonDelete={handlePersonDelete}/>
            </div>            
        </div>
    )
}

export default Person