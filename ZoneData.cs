public static class ZoneData
{
    public static readonly List<Zone> Act1Zones = new List<Zone>
    {
        // Example: new Zone("Zone Name", Act Number, IsCity, HasWaypoint, IsBossArea)
        new Zone("The Twilight Strand", 1, false, false, true, "kill hillock"),
        new Zone("Lioneye's Watch", 1, true, true, false),
        new Zone("The Coast", 1, false, true, false),
        new Zone("The Tidal Island", 1, false, false, true),
        new Zone("The Mud Flats", 1, false, false, false),
        new Zone("The Fetid Pool", 1, false, false, true),
        new Zone("The Submerged Passage", 1, false, true, false),
        new Zone("The Flooded Depths", 1, false, false, true),
        new Zone("The Ledge", 1, false, true, false),
        new Zone("The Climb", 1, false, false, false),
        new Zone("The Lower Prison", 1, false, false, false),
        new Zone("The Upper Prison", 1, false, false, false),
        new Zone("Prisoner's Gate", 1, false, true, false),
        new Zone("The Ship Graveyard", 1, false, false, false),
        new Zone("The Ship Graveyard Cave", 1, false, false, true),
        new Zone("The Cavern of Wrath", 1, false, false, false),
        new Zone("The Cavern of Anger", 1, false, false, false)
    };

    public static readonly List<Zone> Act2Zones = new List<Zone>
    {
        new Zone("The Southern Forest", 2, false, true, false),
        new Zone("The Forest Encampment", 2, true, true, false),
        new Zone("The Old Fields", 2, false, true, false),
        new Zone("The Den", 2, false, false, true),
        new Zone("The Crossroads", 2, false, true, false),
        new Zone("The Chamber of Sins Level 1", 2, false, false, false),
        new Zone("The Chamber of Sins Level 2", 2, false, false, true),
        new Zone("The Broken Bridge", 2, false, true, false),
        new Zone("The Fellshrine Ruins", 2, false, false, false),
        new Zone("The Crypt Level 1", 2, false, false, false),
        new Zone("The Crypt Level 2", 2, false, false, true),
        new Zone("The Western Forest", 2, false, true, false),
        new Zone("The Weaver's Chambers", 2, false, false, true),
        new Zone("The Wetlands", 2, false, true, false),
        new Zone("The Vaal Ruins", 2, false, false, false),
        new Zone("The Northern Forest", 2, false, true, false),
        new Zone("The Dread Thicket", 2, false, false, false),
        new Zone("The Caverns", 2, false, false, false),
        new Zone("The Ancient Pyramid", 2, false, false, true)
    };

    // Define similar lists for Acts 3, through 10
    public static readonly List<Zone> Act3Zones = new List<Zone>
    {
        new Zone("The City of Sarn", 3, true, true, false),
        new Zone("The Sarn Encampment", 3, true, true, false),
        new Zone("The Slums", 3, false, true, false),
        new Zone("The Crematorium", 3, false, false, false),
        new Zone("The Sewers", 3, false, false, false),
        new Zone("The Marketplace", 3, false, true, false),
        new Zone("The Catacombs", 3, false, false, false),
        new Zone("The Battlefront", 3, false, true, false),
        new Zone("The Solaris Temple Level 1", 3, false, false, false),
        new Zone("The Solaris Temple Level 2", 3, false, false, true),
        new Zone("The Docks", 3, false, true, false),
        new Zone("The Lunaris Temple Level 1", 3, false, false, false),
        new Zone("The Lunaris Temple Level 2", 3, false, false, true),
        new Zone("The Imperial Gardens", 3, false, true, false),
        new Zone("The Library", 3, false, false, false),
        new Zone("The Archives", 3, false, false, false),
        new Zone("The Sceptre of God", 3, false, false, true)
    };

    public static readonly List<Zone> Act4Zones = new List<Zone>
    {
        new Zone("The Aqueduct", 4, false, true, false),
        new Zone("Highgate", 4, true, true, false),
        new Zone("The Dried Lake", 4, false, true, false),
        new Zone("The Mines Level 1", 4, false, false, false),
        new Zone("The Mines Level 2", 4, false, false, false),
        new Zone("Kaom's Dream", 4, false, false, true),
        new Zone("Kaom's Stronghold", 4, false, false, false),
        new Zone("Daresso's Dream", 4, false, false, true),
        new Zone("The Grand Arena", 4, false, false, false),
        new Zone("The Belly of the Beast Level 1", 4, false, false, false),
        new Zone("The Belly of the Beast Level 2", 4, false, false, true)
    };

    public static readonly List<Zone> Act5Zones = new List<Zone>
    {
        new Zone("The Slave Pens", 5, false, false, false),
        new Zone("Overseer's Tower", 5, false, false, true),
        new Zone("Control Blocks", 5, false, false, false),
        new Zone("Oriath Square", 5, false, true, false),
        new Zone("The Templar Courts", 5, false, true, false),
        new Zone("Chamber of Innocence", 5, false, false, true),
        new Zone("The Torched Courts", 5, false, true, false),
        new Zone("The Ruined Square", 5, false, true, false),
        new Zone("The Ossuary", 5, false, false, false),
        new Zone("The Reliquary", 5, false, false, false),
        new Zone("The Cathedral Rooftop", 5, false, false, true)
    };

    // Define similar lists for Acts 6, through 10
    public static readonly List<Zone> Act6Zones = new List<Zone>
    {
        new Zone("The Twilight Strand", 6, false, false, true),
        new Zone("Lioneye's Watch", 6, true, true, false),
        new Zone("The Coast", 6, false, true, false),
        new Zone("The Mud Flats", 6, false, false, false),
        new Zone("The Karui Fortress", 6, false, false, false),
        new Zone("The Ridge", 6, false, true, false),
        new Zone("The Lower Prison", 6, false, false, false),
        new Zone("Shavronne's Tower", 6, false, false, true),
        new Zone("Prisoner's Gate", 6, false, true, false),
        new Zone("The Western Forest", 6, false, true, false),
        new Zone("The Riverways", 6, false, true, false),
        new Zone("The Wetlands", 6, false, true, false),
        new Zone("The Southern Forest", 6, false, true, false),
        new Zone("The Cavern of Anger", 6, false, false, false),
        new Zone("The Beacon", 6, false, false, true),
        new Zone("The Brine King's Reef", 6, false, false, true)
    };

    public static readonly List<Zone> Act7Zones = new List<Zone>
    {
        new Zone("The Bridge Encampment", 7, true, true, false),
        new Zone("The Broken Bridge", 7, false, true, false),
        new Zone("The Crossroads", 7, false, true, false),
        new Zone("The Fellshrine Ruins", 7, false, false, false),
        new Zone("The Crypt", 7, false, false, false),
        new Zone("The Chamber of Sins Level 1", 7, false, false, false),
        new Zone("Maligaro's Sanctum", 7, false, false, true),
        new Zone("The Chamber of Sins Level 2", 7, false, false, true),
        new Zone("The Den", 7, false, false, false),
        new Zone("The Ashen Fields", 7, false, true, false),
        new Zone("The Northern Forest", 7, false, true, false),
        new Zone("The Causeway", 7, false, true, false),
        new Zone("The Vaal City", 7, false, true, false),
        new Zone("The Temple of Decay Level 1", 7, false, false, false),
        new Zone("The Temple of Decay Level 2", 7, false, false, true)
    };

    public static readonly List<Zone> Act8Zones = new List<Zone>
    {
        new Zone("The Sarn Ramparts", 8, false, true, false),
        new Zone("The Sarn Encampment", 8, true, true, false),
        new Zone("The Toxic Conduits", 8, false, true, false),
        new Zone("Doedre's Cesspool", 8, false, false, false),
        new Zone("The Grand Promenade", 8, false, true, false),
        new Zone("The Quay", 8, false, true, false),
        new Zone("The Grain Gate", 8, false, true, false),
        new Zone("The Imperial Fields", 8, false, true, false),
        new Zone("The Solaris Concourse", 8, false, true, false),
        new Zone("The Harbour Bridge", 8, false, true, false),
        new Zone("The Lunaris Concourse", 8, false, true, false),
        new Zone("The Harbour Encampment", 8, true, true, false)
    };

    public static readonly List<Zone> Act9Zones = new List<Zone>
    {
        new Zone("The Blood Aqueduct", 9, false, true, false),
        new Zone("Highgate", 9, true, true, false),
        new Zone("The Descent", 9, false, false, false),
        new Zone("The Vastiri Desert", 9, false, true, false),
        new Zone("The Oasis", 9, false, false, false),
        new Zone("The Foothills", 9, false, true, false),
        new Zone("The Boiling Lake", 9, false, false, false),
        new Zone("The Tunnel", 9, false, false, false),
        new Zone("The Quarry", 9, false, false, false),
        new Zone("The Refinery", 9, false, false, false),
        new Zone("The Belly of the Beast", 9, false, false, true),
        new Zone("The Rotting Core", 9, false, false, true)
    };

    public static readonly List<Zone> Act10Zones = new List<Zone>
    {
        new Zone("Oriath Docks", 10, true, true, false),
        new Zone("The Cathedral Rooftop", 10, false, false, true),
        new Zone("The Ravaged Square", 10, false, true, false),
        new Zone("The Ossuary", 10, false, false, false),
        new Zone("The Torched Courts", 10, false, true, false),
        new Zone("The Reliquary", 10, false, false, false),
        new Zone("The Canals", 10, false, true, false),
        new Zone("The Feeding Trough", 10, false, false, false)
    };

    public static readonly List<Zone> EpilogueZones = new List<Zone>
    {
        new Zone("Karui Shores", 11, true, true, false)

    };


    public static readonly List<Zone> Zones = new List<List<Zone>> { Act1Zones, Act2Zones, Act3Zones, Act4Zones, Act5Zones, Act6Zones, Act7Zones, Act8Zones, Act9Zones, Act10Zones }
        .SelectMany(z => z)
        .ToList();

}
